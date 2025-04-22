
CREATE TABLE Users (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Username TEXT NOT NULL UNIQUE,
    Password TEXT NOT NULL
);

CREATE TABLE Products (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    Name TEXT NOT NULL,
    Price REAL NOT NULL,
    Image TEXT NOT NULL,
    Description TEXT
);

CREATE TABLE CartItems (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    UserId INTEGER,
    ProductId INTEGER,
    Quantity INTEGER,
    FOREIGN KEY(UserId) REFERENCES Users(Id),
    FOREIGN KEY(ProductId) REFERENCES Products(Id)
);

CREATE TABLE Orders (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    UserId INTEGER,
    OrderDate TEXT,
    FOREIGN KEY(UserId) REFERENCES Users(Id)
);

CREATE TABLE OrderItems (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    OrderId INTEGER,
    ProductId INTEGER,
    Quantity INTEGER,
    FOREIGN KEY(OrderId) REFERENCES Orders(Id),
    FOREIGN KEY(ProductId) REFERENCES Products(Id)
);

INSERT INTO Products (Name, Price, Image, Description) VALUES
('Smartphone', 499.00, 'phone.jpg', 'Latest model with amazing features.'),
('Laptop', 999.00, 'laptop.jpg', 'High-performance laptop suitable for gaming and work.');
