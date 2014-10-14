## Pushbullet Web Scraper

Pushbullet Web Scraper is a simple .NET app designed to help monitor websites that don't offer
RSS feeds. It accomplices this by checking a specific element of the page each time it's ran
and if it's different from the last time it will send a notification through Pushbullet (either
to all devices or to a channel).

As of now this app does not implement any way of scheduling so it has to rely on something else
to run it, like Windows Task Scheduler or crontab. Currently it supports a virtually unlimited
amount of monitored websites and different Pushbullet accounts per website.

For more info about the setup or the implementation you can check my blog over [here](http://thgeorgiou.com/monitoring-websites-with-pushbullet-channels/).

## License
This work is licensed under the Creative Commons Attribution 4.0 International License. To 
view a copy of this license, visit http://creativecommons.org/licenses/by/4.0/.

This project uses the following libraries:

* JSON.net (http://james.newtonking.com/json):
The MIT License (MIT)

Copyright (c) 2007 James Newton-King

Permission is hereby granted, free of charge, to any person obtaining a copy of this software
and associated documentation files (the "Software"), to deal in the Software without restriction,
including without limitation the rights to use, copy, modify, merge, publish, distribute,
sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial
portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT
NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

* HtmlAgilityPack (http://htmlagilitypack.codeplex.com/):
Microsoft Public License (Ms-PL): http://htmlagilitypack.codeplex.com/license