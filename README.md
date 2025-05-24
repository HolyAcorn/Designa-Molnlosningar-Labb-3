# Star Wars FFG Book Collection

This Azure Function App provides a lightweight, serverless REST API for managing a personal collection of Star Wars: Fantasy Flight Games (FFG) roleplaying books.

The main purpose of this app is to help collectors:

- Track every book in the FFG Star Wars RPG series
- Mark which books they already own
- Prioritize which ones to collect next using a customizable priority scale

Whether you're collecting books from Edge of the Empire, Age of Rebellion, or Force and Destiny, this tool offers a simple way to organize and monitor your collection through API-based CRUD operations.

Use this API as a backend for your own app, or integrate it with tools like Postman, PowerApps, or a custom frontend

## Table of Contents

1. [Base URL](#base-url)
2. [Properties](#properties)
3. [API Endpoints](#api-endpoints)

    3.1. [Create a Book](#create-a-book)

    3.2. [Get All Books](#get-all-books)

    3.3. [Get Book by ID](#get-a-book-by-id)

    3.4. [Update Book](#update-a-book)

    3.5. [Delete Book](#delete-a-book)

4. [Authorization](#authorization)

##  Base URL
The base URL will depend on your Azure deployment, typically:

```https://<your-function-app-name>.azurewebsites.net/api/```

## Properties:
- **name:** The name of the book
- **type:** Type of the book, is it a Core Rulebook? A Supplement?
- **childOf:** The Core Rulebook the book belongs to. FAD for Force and Destiny, EOE for Edge of the Empire, AOR for Age of Rebellion. If it belongs to none of them, write NA
- **sku:** The SKU of the book
- **wantPriority:** A number between 1-10. 1 is what you want most, 10 is what you want least.
- **price:** Price of the product, two decimals allowed. In USD.
- **owned:** Wheter you own it or not.

## API Endpoints

### Create a Book
**POST /api/book**

Creates a new book. A GUID is automatically assigned.

#### Request Body

```
{
  "name": "Dungeon Master's Guide",
  "type": "Core Rulebook",
  "childOf": null,
  "sku": "DMG-001",
  "wantPriority": 9,
  "price": 39.99,
  "owned": false
}
```

#### Response
```"Book is created, the id is 123e4567-e89b-12d3-a456-426614174000"```

###  Get All Books
**GET /api/books**

Retrieves a list of all books.

#### Response

```
[
  {
    "id": "123e4567-e89b-12d3-a456-426614174000",
    "name": "Player's Handbook",
    "type": "Core Rulebook",
    "childOf": null,
    "sku": "PHB-001",
    "wantPriority": 10,
    "price": 49.99,
    "owned": true
  },
  ...
]
```

### Get a Book by ID
**GET /api/book/{id}**

Retrieves a single book by its id.

Example
```GET /api/book/123e4567-e89b-12d3-a456-426614174000```

#### Response
```
{
  "id": "123e4567-e89b-12d3-a456-426614174000",
  "name": "Monster Manual",
  "type": "Core Rulebook",
  "childOf": null,
  "sku": "MM-001",
  "wantPriority": 7,
  "price": 39.99,
  "owned": false
}
```

### Update a Book
**PUT /api/book/{id}**

Updates an existing book by id.

#### Request Body
```
{
  "id": "123e4567-e89b-12d3-a456-426614174000",
  "name": "Monster Manual - Revised",
  "type": "Supplement",
  "childOf": null,
  "sku": "MM-001-R",
  "wantPriority": 8,
  "price": 42.00,
  "owned": true
}
```


#### Response
```
{
  "id": "123e4567-e89b-12d3-a456-426614174000",
  "name": "Monster Manual - Revised",
  "type": "Supplement",
  "childOf": null,
  "sku": "MM-001-R",
  "wantPriority": 8,
  "price": 42.00,
  "owned": true
}
```

### Delete a Book
**DELETE /api/book/{id}**

Deletes a book by id.


#### Response
``` "The book is deleted: true"```

## Authorization
All endpoints use Function level authorization. Make sure to include your function key when calling these endpoints unless running locally or with anonymous access enabled.

