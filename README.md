# Terra Sales

This is a Web API build in .NET Framework 4.7.2

It has Swagger for documentation: http://localhost:56830/swagger


There are four methods called: 
* GetOrderById: http://localhost:56830/api/sales/ordersById/1 [GET]
* CreateOrder: http://localhost:56830/api/sales/CreateOrder [POST]
* DeleteOrder: http://localhost:56830/api/sales/DeleteOrder [DELETE]
* EditOrder: http://localhost:56830/api/sales/EditOrder [PUT]

Each methods uses an input, these inputs has Data Annotations to make them required and handle Regular Expresions.

There is only one standard output that has three properties:
* A viewModel than contains the Order Model and a list of details for that OrderId
* Result: It is an Enum that has only two values (Success, NorFound and Error).


```
For method GetOrderById, the request is a Uri param called OrderId.

For CreateOrder, the body request is:

{
  "userName": "string",
  "details": [
    {
      "description": "string",
      "price": 0
    }
  ]
}

For DeleteOrder, the body request is:

{
  "OrderId": 0
}

For EditOrder, the body request is:

{
  "OrderId": 0,
  "details": [
    {
      "Sequence": 0,
      "description": "string",
      "price": 0
    }
  ]
}

The output response is:

{
  "salesOrder": {
    "OrderID": 0,
    "OrderNumber": 0,
    "UserName": "string"
  },
  "salesOrderDetails": [
    {
      "OrderID": 0,
      "Sequence": 0,
      "Description": "string",
      "Price": 0
    }
  ],
  "Result": "Success"
}

```