CREATE TABLE Product (
    ProductId INT PRIMARY KEY,
    Code NVARCHAR(50) NOT NULL,
    Stoc INT
);

CREATE TABLE OrderHeader (
    OrderId INT PRIMARY KEY,
    Address NVARCHAR(255),
    Total DECIMAL(10, 2) 
);

CREATE TABLE OrderLine (
    OrderLineId INT PRIMARY KEY,
    ProductId INT,
    Quantity INT,
    Price DECIMAL(10, 2),
    FOREIGN KEY (ProductId) REFERENCES Product(ProductId)
);
