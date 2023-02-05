# YannikG.PageableData
A lightweight package that helps you with pageable data in your dotnet application.

# 💡 Motivation
This package was created when switching back from using Java Spring Boot in my daily work. I missed the easy-to-use paging and built my own. This package is lightweight and easy to extend.

# Quick Links
- [Project on Nuget.org](https://www.nuget.org/packages/YannikG.PageableData/)
- [Spring Boot implementation](https://www.baeldung.com/spring-data-jpa-pagination-sorting)
- Read [Master the Art of Pagination in .NET 6.0 with YannikG.PageableData: An Easy Guide](https://medium.com/@gartmann-yannik/learn-how-to-easily-implement-pagination-in-net-6-0-with-yannikg-pageabledata-d0e13316068e) on Medium.com

# Get started
## Installation
`dotnet add package YannikG.PageableData`

Add using in your project `using YannikG.PageableData`

## How to use it
The `IPageable` interfaces gives you a toolbox of useful and standardized properties. Within your API request you specify what page you want and how big it should be (numbers of maximum result). Additionally, you have the possibility to send a field name, that should be sorted along with the sorting direction. The sorting is done in your data access logic. This package doesn’t do anything with your database queries. It just provides you an easy to use toolbox.

When querying your data, `IPageable` provides you with useful helpers like a pre calculated `Skip` and `Take`, so you don’t have to do it on your own 🎉.
To transport data back through your logic and return it back to the requester, you can use `IDataPage`. `IDataPage` describes a class that can hold a `IPageable` along the data.

Modern frontend frameworks and UI libraries will easily be able to work with this data structure.

I use this package with Angular Material, and it works just fine.

## 📚 Example Walkthrough
We assume, we are sending a GET Request to a weather forecast endpoint that should return the second page (page numbers start at 0) with 10 results and should be sorted ascending (value 1 [descending = -1]) by the field “Citiy”:

`https://example.com/WeatherForecast?PageSize=10&CurrentPage=1&SortByField=City&SortDirection=1`

This call returns the following data:

```
{
  "totalItems": 34,
  "totalItemsOnPage": 10,
  "content": [
    {
      "city": "Frauenfeld",
      "date": "2022-06-15T20:52:26.599853+02:00",
      "temperatureC": 32,
      "temperatureF": 89,
      "summary": "Scorching"
    },
    ...
    {
      "city": "Lugano",
      "date": "2022-06-15T20:52:26.599857+02:00",
      "temperatureC": 44,
      "temperatureF": 111,
      "summary": "Sweltering"
    }
  ],
  "totalPages": 4,
  "pageSize": 10,
  "currentPage": 1,
  "isSorted": true,
  "sortByField": "City",
  "sortDirection": 1
}
```

Looks great, doesn’t it? 😎

### Provided Example Application
Within the source you will find an example implementation that should give you an idea how the package should be used. If you have any question regarding the package or example, you can create an issue.

## 🤘 Contribute
Feel free to make changes and add a pull request.
