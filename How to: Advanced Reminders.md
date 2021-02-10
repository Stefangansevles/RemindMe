# Advanced Reminders

This page will explain how you can set up Advanced Reminders for RemindMe. Keep in mind, this feature is for advanced users.

To create an "Advanced Reminder", first select the option in the "settings" tab:

<img src="https://i.imgur.com/83a0YQ8.png" width="50%"></img>

Like the message suggests, you now have a new button when creating reminders:

<img src="https://i.imgur.com/KHo1294.png" width="50%"></img>

With this new feature, you can do two new things: 


## 1. API Support

From RemindMe version 3.1.0 and onwards, you will be able to configure reminders that listen to API(s). 

### But what can i do with this?

Well, the possible things you can do with this are endless, but to give an example to my use-case: I have multiple conditional reminders set-up. Each reminder will
use the "Coingecko" API to check the price of a specific crypto-currency unit, for example Swissborg. When the price number on this page ( https://www.coingecko.com/en/coins/swissborg )
reaches $1.00 or higher, RemindMe will automatically notify me by showing an reminder.

<img src="https://i.imgur.com/7r2zAIE.png" width=50%></img>

As you can see, I have this set-up for multiple reminders. This means that RemindMe automatically checks the prices of multiple coins, without me having to do any work!
If you're not into crypto, you can also use this for anything else that has an public OR private(requires adding authenication to the 'other headers') API. I'll leave what you
want to do with that up to you :)

### How do i set it up?

See the following image:

<img src="https://i.imgur.com/9M66PRf.png" width="70%"></img>

From this interface, there are multiple things you can configure for your reminder. Please see the table below for an explanation on these properties.

| Field  | Explanation | Required |
| ------------- | ------------- | -------------|
| URL  | The full URL path to the API endpoint, including potential parameters  | ✔️  | 
| Type  | "GET" or "SET", the type of API call  | ✔️  | 
| Accept Header  | An optional HTTP "Accept" header  | ❌  | 
| Content-Type Header  | An optional HTTP "Content-Type" header  | ❌  | 
| Interval  | How often this reminder will ping the API to evaluate the condition(s), every {interval} minutes  | ✔️  | 
| On Popup  | What this reminder should do once the condition has been met. Either Delete itself(stop), or keep checking every <interval> (Repeat)  | ✔️  | 
| Other Headers  | Other headers you wish to send to the API endpoint, for example a HTTP Authorization header. This should be in JSON format  | ❌  | 
| Body  | The body data you wish to post to the API endpoint (only visible on POST, not on GET). This should be in JSON format  | ❌  | 

And for the rule section:

| Field  | Explanation | Required |
| ------------- | ------------- | -------------|
| Condition  | The type of condition, for now only "IF" is available  | ✔️  | 
| Data Type  | The data type of the property of the JSON response from the API (double, string, boolean)  | ✔️  | 
| Property  | The property you wish to check on. This is the name of the property in the JSON response. If it is nested, use dots ( "." ) | ✔️  | 
| Operator  | The operator to use on this condition, >, <, ==, etc  | ✔️  | 
| Value  | The value the property should have, for example {Property} >= {value}  | ✔️  | 

### How does it work?
Once all required fields have been filled in, you can add conditional logic. Note that you can add multiple conditions to a single reminder by pressing the "+" button! The reminder will
evaluate all conditions, and the conditions share an AND relation. So for example:

``` If ( (double) price > 10 AND (double) price < 20 AND (string) name startsWith sometext ) ```

If all 3 conditions evaluate to ```true``` then the reminder will pop up.

The reminder will check the 'property' on the JSON response from the API. For example, see this response from coingecko:

<img src="https://i.imgur.com/FI9h5gl.png" width="50%"></img>

If for example you want to check on the price of Swissborg in australian dollars(aud) you would type ```market_data.current_price.aud``` in the property field, and select 
```double``` in the ```Data Type``` field, since it is a numeric value

You can press the test button to check the connection to the API and to evaluate the condition(s).

Once everything looks good, you can press save. You're all set and you should see an reminder with an indicator that it is an conditional reminder! (www)

<img src="https://i.imgur.com/yeQzKst.png"></img>

Conditional reminders are loaded into the list after normal reminders, so you might have to switch pages.

### What doesn't work

Looping over arrays inside a JSON API response is not yet implemented. This might get implemented in the future.

### Note

The "hide reminder" function from the "batch" tab will also work in combination with API reminders. Once the API condition has been met, you can configure it to execute the batch
code (or leave it empty) and show (or don't show) a reminder pop-up.

---------------


## 2. Windows Batch script code

Advanced Reminders can execute batch code when the reminder pops up. You can do a lot of things with that, but I'll leave that up to you ;)

<img src="https://i.imgur.com/eKla3ST.png" width="70%"></img>

I've pasted some example batch code to demonstrate it.

The reminder will now also have a different icon to indicate that it is an Advanced Reminder with batch code enabled. When you hover over the icon you will be able to quickly see the batch code:

<img src="https://i.imgur.com/jS3jNad.png" width="70%"></img>

To demonstrate how it looks when it pops up, I've made a .gif

<img src="https://i.imgur.com/C5gcAEV.gif" width="70%"></img>
