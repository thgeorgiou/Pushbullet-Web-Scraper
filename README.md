## Pushbullet Web Scraper

Pushbullet Web Scraper is a simple .NET app designed to help monitor websites that don't offer
RSS feeds. It accomplices this by checking a specific element of the page each time it's ran
and if it's different from the last time it will send a notification through Pushbullet (either
to all devices or to a channel).

As of now this app does not implement any way of scheduling so it has to rely on something else
to run it, like Windows Task Scheduler or crontab. Currently it supports a virtually unlimited
amount of monitored websites and different Pushbullet accounts per website.

For more info about the setup or the implementation you can check my blog over [here]().

## License
