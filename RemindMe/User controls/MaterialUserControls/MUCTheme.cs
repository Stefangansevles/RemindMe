using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using Business_Logic_Layer;
using Database.Entity;

namespace RemindMe
{
    public partial class MUCTheme : UserControl
    {
        private Themes currentSelectedTheme = null;
        public MUCTheme()
        {
            InitializeComponent();

            cbPrimary.SelectedIndexChanged += colorSchemeIndexChanged;
            cbDarkPrimary.SelectedIndexChanged += colorSchemeIndexChanged;
            cbLightPrimary.SelectedIndexChanged += colorSchemeIndexChanged;
            cbAccent.SelectedIndexChanged += colorSchemeIndexChanged;
            cbTextShade.SelectedIndexChanged += colorSchemeIndexChanged;

            
            
            

            //Load theme from DB
            Settings set = BLLocalDatabase.Setting.Settings;
            if (set.CurrentTheme.HasValue && set.CurrentTheme.Value != -1) //Theres a theme
            {
                Themes theme = BLLocalDatabase.Theme.GetThemeById(set.CurrentTheme.Value);
                if (theme != null)
                {
                    LoadTheme(theme);
                    return; //Dont do the code below
                }

            }

           
        }

        private void colorSchemeIndexChanged(object sender, EventArgs e)
        {
            try
            {                
                Primary p = (Primary)Enum.Parse(typeof(Primary), cbPrimary.SelectedItem.ToString());
                Primary dp = (Primary)Enum.Parse(typeof(Primary), cbDarkPrimary.SelectedItem.ToString());
                Primary lp = (Primary)Enum.Parse(typeof(Primary), cbLightPrimary.SelectedItem.ToString());
                Accent acc = (Accent)Enum.Parse(typeof(Accent), cbAccent.SelectedItem.ToString());
                TextShade ts = (TextShade)Enum.Parse(typeof(TextShade), cbTextShade.SelectedItem.ToString());
                MaterialForm1.MaterialSkinManager.ColorScheme = new ColorScheme(p, dp, lp, acc, ts);
                
                //Make sure the form header also changes color
                MaterialForm1.Instance.Invalidate();
            }
            catch { }
        }


        int shuffleIndex = 0;
        private void btnChangeColors_Click(object sender, EventArgs e)
        {
            List<Themes> themes = BLLocalDatabase.Theme.GetThemes();            
            LoadTheme(themes[shuffleIndex]);

            if (shuffleIndex < themes.Count-1)
                shuffleIndex++;
            else
                shuffleIndex = 0;
            
            MaterialForm1.Instance.Invalidate();
        }

        private void materialSwitch4_CheckedChanged(object sender, EventArgs e)
        {
            MaterialForm1.Instance.DrawerUseColors = swColors.Checked;

            Settings set = BLLocalDatabase.Setting.Settings;
            set.DrawerUseColors = swColors.Checked ? 1 : 0;
            BLLocalDatabase.Setting.UpdateSettings(set);
        }

        private void materialSwitch5_CheckedChanged(object sender, EventArgs e)
        {
            MaterialForm1.Instance.DrawerHighlightWithAccent = swDrawerHighlight.Checked;

            Settings set = BLLocalDatabase.Setting.Settings;
            set.DrawerHighlight = swDrawerHighlight.Checked ? 1 : 0;
            BLLocalDatabase.Setting.UpdateSettings(set);
        }

        private void materialSwitch6_CheckedChanged(object sender, EventArgs e)
        {
            MaterialForm1.Instance.DrawerBackgroundWithAccent = swDrawerBackground.Checked;

            Settings set = BLLocalDatabase.Setting.Settings;
            set.DrawerBackground= swDrawerBackground.Checked ? 1 : 0;
            BLLocalDatabase.Setting.UpdateSettings(set);
        }

        private void materialButton7_Click(object sender, EventArgs e)
        {
            MaterialForm1.MaterialSkinManager.Theme = MaterialForm1.MaterialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? MaterialSkinManager.Themes.LIGHT : MaterialSkinManager.Themes.DARK;

            //Update all icons accordingly
            MaterialForm1.Instance.UpdateTheme(null);

            SetThemeText();
        }

        private void btnSaveTheme_Click(object sender, EventArgs e)
        {
            if(currentSelectedTheme != null)
            {
                if (MaterialRemindMeBox.Show
                     ("Do you want to update the current theme, or save it under a new name? Press YES to update the current theme (\"" + currentSelectedTheme.ThemeName + "\"), and NO to save it under a new name.",
                     RemindMeBoxReason.YesNo) == DialogResult.Yes)
                {
                    if(currentSelectedTheme.IsDefault == 1)
                    {
                        MaterialRemindMeBox.Show("The selected theme is a default theme. You can't edit this theme. If you want to " +
                            "save this theme, save it under a different name instead (Press NO after saving)");

                        return;
                    }

                    //Update current theme                                        
                    currentSelectedTheme.Primary = (int)Enum.Parse(typeof(Primary), cbPrimary.SelectedItem.ToString());
                    currentSelectedTheme.DarkPrimary = (int)Enum.Parse(typeof(Primary), cbDarkPrimary.SelectedItem.ToString());
                    currentSelectedTheme.LightPrimary = (int)Enum.Parse(typeof(Primary), cbLightPrimary.SelectedItem.ToString());
                    currentSelectedTheme.Accent = (int)Enum.Parse(typeof(Accent), cbAccent.SelectedItem.ToString());
                    currentSelectedTheme.TextShade = (int)Enum.Parse(typeof(TextShade), cbTextShade.SelectedItem.ToString());                    

                    currentSelectedTheme.Mode = (int)MaterialSkinManager.Instance.Theme;

                    BLLocalDatabase.Theme.UpdateTheme(currentSelectedTheme);
                    MaterialMessageFormManager.MakeMessagePopup("Succesfully updated theme \"" + currentSelectedTheme.ThemeName + "\"", 5);
                }
                else
                    SaveNewTheme(MaterialRemindMePrompt.ShowText("Give this theme a name "));
            }
            else //No currently selected thme, save as new theme
                SaveNewTheme(MaterialRemindMePrompt.ShowText("Give this theme a name "));
            
        }

        private void SaveNewTheme(string name)
        {            
            if (string.IsNullOrWhiteSpace(name))
                return;

            Themes theme = new Themes();
            theme.Primary = (int)Enum.Parse(typeof(Primary), cbPrimary.SelectedItem.ToString());
            theme.DarkPrimary = (int)Enum.Parse(typeof(Primary), cbDarkPrimary.SelectedItem.ToString());
            theme.LightPrimary = (int)Enum.Parse(typeof(Primary), cbLightPrimary.SelectedItem.ToString());

            theme.Accent = (int)Enum.Parse(typeof(Accent), cbAccent.SelectedItem.ToString());

            theme.TextShade = (int)Enum.Parse(typeof(TextShade), cbTextShade.SelectedItem.ToString());

            theme.ThemeName = name;

            theme.Mode = (int)MaterialSkinManager.Instance.Theme;

            BLLocalDatabase.Theme.InsertTheme(theme);

            ComboBoxItem item = new ComboBoxItem(theme.ThemeName, theme.Id);
            cbLoadTheme.Items.Add(item);
            cbLoadTheme.SelectedItem = item;

            currentSelectedTheme = theme;
            //Update the settings table
            Settings set = BLLocalDatabase.Setting.Settings;
            set.CurrentTheme = theme.Id;
            BLLocalDatabase.Setting.UpdateSettings(set);

            MaterialMessageFormManager.MakeMessagePopup("Succesfully saved theme \"" + name + "\" under your saved themes.", 5);
        }

        private void LoadTheme(Themes theme)
        {

            Primary p = (Primary)Enum.Parse(typeof(Primary), theme.Primary.ToString());
            Primary dp = (Primary)Enum.Parse(typeof(Primary), theme.DarkPrimary.ToString());
            Primary lp = (Primary)Enum.Parse(typeof(Primary), theme.LightPrimary.ToString());
            Accent acc = (Accent)Enum.Parse(typeof(Accent), theme.Accent.ToString());
            TextShade ts = (TextShade)Enum.Parse(typeof(TextShade), theme.TextShade.ToString());

            cbPrimary.SelectedIndex = Array.IndexOf(Enum.GetValues(p.GetType()), p);
            cbDarkPrimary.SelectedIndex = Array.IndexOf(Enum.GetValues(dp.GetType()), dp);
            cbLightPrimary.SelectedIndex = Array.IndexOf(Enum.GetValues(lp.GetType()), lp);

            cbAccent.SelectedIndex = Array.IndexOf(Enum.GetValues(acc.GetType()), acc);
            cbTextShade.SelectedIndex = Array.IndexOf(Enum.GetValues(ts.GetType()), ts);

            MaterialSkinManager.Instance.Theme = (MaterialSkinManager.Themes)theme.Mode;
            currentSelectedTheme = theme;
            Settings set = BLLocalDatabase.Setting.Settings;
            set.CurrentTheme = theme.Id;
            BLLocalDatabase.Setting.UpdateSettings(set);            
        }


        private void MUCTheme_Load(object sender, EventArgs e)
        {
            Settings set = BLLocalDatabase.Setting.Settings;

            //Load preferences from DB
            swColors.Checked = Convert.ToBoolean(set.DrawerUseColors);
            swDrawerBackground.Checked = Convert.ToBoolean(set.DrawerBackground);

            if (set.DrawerHighlight == null) set.DrawerHighlight = 1;

            swDrawerHighlight.Checked = Convert.ToBoolean(set.DrawerHighlight);

            bool firstUse = false;
            if (BLLocalDatabase.Theme.GetThemes().Count == 0)
            {
                BLLocalDatabase.Theme.InsertDefaultThemes(); //This should really only happen once, on first startup                
                firstUse = true;
            }

            foreach (Themes theme in BLLocalDatabase.Theme.GetThemes())
            {
                ComboBoxItem item = new ComboBoxItem(theme.ThemeName, theme.Id);
                cbLoadTheme.Items.Add(item);

                if (currentSelectedTheme != null && currentSelectedTheme.Id == theme.Id)
                {
                    //select this one
                    cbLoadTheme.SelectedItem = item;
                }
            }

            foreach (Primary prim in (Primary[])Enum.GetValues(typeof(Primary)))
            {
                cbPrimary.Items.Add(new ComboBoxItem(prim.ToString(), prim));
                cbDarkPrimary.Items.Add(new ComboBoxItem(prim.ToString(), prim));
                cbLightPrimary.Items.Add(new ComboBoxItem(prim.ToString(), prim));
            }
            foreach (Accent acc in (Accent[])Enum.GetValues(typeof(Accent)))
            {
                cbAccent.Items.Add(new ComboBoxItem(acc.ToString(), acc));
            }
            foreach (TextShade ts in (TextShade[])Enum.GetValues(typeof(TextShade)))
            {
                cbTextShade.Items.Add(new ComboBoxItem(ts.ToString(), ts));
            }

            if (set.CurrentTheme == -1)
            {
                cbPrimary.SelectedIndex = Array.IndexOf(Enum.GetValues(Primary.Indigo500.GetType()), Primary.Indigo500);
                cbDarkPrimary.SelectedIndex = Array.IndexOf(Enum.GetValues(Primary.Indigo700.GetType()), Primary.Indigo700);
                cbLightPrimary.SelectedIndex = Array.IndexOf(Enum.GetValues(Primary.Indigo100.GetType()), Primary.Indigo100);
                cbAccent.SelectedIndex = Array.IndexOf(Enum.GetValues(Accent.Pink200.GetType()), Accent.Pink200);
                cbTextShade.SelectedIndex = Array.IndexOf(Enum.GetValues(TextShade.WHITE.GetType()), TextShade.WHITE);
            }

            if (firstUse)
                LoadTheme(BLLocalDatabase.Theme.GetThemes()[0]); //dark-red


        }
        private void SetThemeText()
        {
            if (MaterialForm1.MaterialSkinManager.Theme == MaterialSkinManager.Themes.DARK)
                btnTheme.Text = "Light mode";
            else
                btnTheme.Text = "Dark mode";
        }

        private void MUCTheme_VisibleChanged(object sender, EventArgs e)
        {
            SetThemeText();
        }

        private void btnOldRemindMeTheme_Click(object sender, EventArgs e)
        {
            if(MaterialRemindMeBox.Show("Are you sure you want to switch to the old RemindMe UI?", RemindMeBoxReason.YesNo) == DialogResult.Yes)
            {
                Settings set = BLLocalDatabase.Setting.Settings;
                set.MaterialDesign = 0;
                BLLocalDatabase.Setting.UpdateSettings(set);
                MaterialForm1.Instance.shouldClose = true;
                Application.Restart();
            }
        }

        private void cbLoadTheme_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxItem c = (ComboBoxItem)cbLoadTheme.SelectedItem;
            LoadTheme(BLLocalDatabase.Theme.GetThemeById((long)c.Value));
        }

        private void btnDeleteTheme_Click(object sender, EventArgs e)
        {
            if (cbLoadTheme.SelectedItem == null) return;

            ComboBoxItem c = (ComboBoxItem)cbLoadTheme.SelectedItem;
            if (c == null || c.Value == null) return;

            Themes selectedTheme = BLLocalDatabase.Theme.GetThemeById((long)c.Value);
            if (selectedTheme == null) return;

            if (MaterialRemindMeBox.Show
                    ("Are you sure you want to delete the theme \"" + selectedTheme.ThemeName + "\" ?", RemindMeBoxReason.YesNo) == DialogResult.Yes)
            {
                
                BLLocalDatabase.Theme.DeleteThemeById(selectedTheme.Id);

                //Reset currentTheme in table `Settings` to -1
                Settings set = BLLocalDatabase.Setting.Settings;
                set.CurrentTheme = -1;
                BLLocalDatabase.Setting.UpdateSettings(set);

                cbLoadTheme.Items.Remove(cbLoadTheme.SelectedItem);
                cbLoadTheme.Text = "";
                currentSelectedTheme = null;
            }
        }
    }
}
