# Word_Of_The_Day
This application show a random word with its definition and example every hour and read them.
This copy allows the user to add new words, edit existance once and remove words.
it uses sqlite database with entity framework 6
I also included Oxford api to get new words, I've used the free 3k requests a month offer
Note that not all Oxford words have example and type, I didn't parse all oxford response json, I only parsed what I needed
The applicaton automatically puts itself in the startup when first run, you can change that by the context menu
