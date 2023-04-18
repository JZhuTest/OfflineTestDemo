[![npm version](https://badge.fury.io/js/angular2-expandable-list.svg)](https://badge.fury.io/js/angular2-expandable-list)
[![code style: prettier](https://img.shields.io/badge/code_style-prettier-ff69b4.svg?style=flat-square)](https://github.com/prettier/prettier)

# OfflineTestDemo

> Demo a small website for showing or ordering pizzas. It is using .Net Core WebAPI as backend and using React as frontend.

## Prerequisites

This project requires .NET 6 SDK, NodeJS (version 8 or later) and NPM.
[.NET 6 SDK](https://dotnet.microsoft.com/download) can be download by clicking the link
[Node](http://nodejs.org/) and [NPM](https://npmjs.org/) are really easy to install.
To make sure you have them available on your machine,
try running the following command.

```sh
$ npm -v && node -v
6.4.1
v8.16.0
```

## Table of contents

- [Project Name](#offlinetestdemo)
  - [Prerequisites](#prerequisites)
  - [Table of contents](#table-of-contents)
  - [Getting Started](#getting-started)
  - [Installation](#installation)
  - [Usage](#usage)
    - [Running the web api](#running-the-web-api)
    - [Running the web api tests](#running-the-web-api-tests)
    - [Running the website](#running-the-website)
    - [Running the website tests](#running-the-website-tests)
  - [TODO list](#todo-list)
  - [Authors](#authors)
  - [License](#license)

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes. See deployment for notes on how to deploy the project on a live system.

## Installation

**BEFORE YOU INSTALL:** please read the [prerequisites](#prerequisites)

Start with cloning this repo on your local machine:

```sh
$ git clone https://github.com/ORG/PROJECT.git
$ cd PROJECT
```

## Usage

### Running the web api

```sh
$ cd backend/PizzeriaDemoAPI
$ dotnet run
```
### Running the web api tests

```sh
$ cd backend/PizzeriaDemoAPITests
$ dotnet test
```

### Running the website

```sh
$ cd frontend/public
$ npm start
```

### Running the website tests

```sh
$ cd frontend/public
$ npm test
```

## TODO list

- backend
  - implement the API functions for add/update/delete locations and add/update/delete menus
  - add authorization for the private admin site
  - change the entire API to be async instead of sync
  - generate swagger API document page
  - add more unit tests to cover most controller, services and repositories
- frontend
  - implement the private admin site using React: edit or add location and menus, login page
  - add more unit tests using jest
  - apply redux for this site

## Authors

* **James Zhu** - *Initial work* 

## License

[MIT License](https://andreasonny.mit-license.org/2019) © Andrea SonnY