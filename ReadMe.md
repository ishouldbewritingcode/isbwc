# isbwc (i should be writing code)

* Multi-tenant CMS
* written with CLEAN architecture
* SOLID principles
* Verticle Slice
* Dependency Injection
* API pulls Application features through Dependency Injection
* Currently using SQLLite for simplicity in testing
* React project is just getting started at this point

## Database explaination
* site contains URLs
* site contains pages
* site contains users (for admin)
* pages contain summary
* pages contain blocks of type (blog, news, events, cards) (many to many) A block can exist on one or more pages.
* blocks contain items



