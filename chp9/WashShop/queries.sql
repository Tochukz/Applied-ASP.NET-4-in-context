-- Create the database
create database washshop

-- Create Customers Table
  use washshop
  CREATE TABLE customers(
    id INT IDENTITY NOT NULL PRIMARY KEY,
    firstname VARCHAR(15) NOT NULL,
    lastname VARCHAR(15) NOT NULL,
    email VARCHAR(22) NOT NULL UNIQUE,
    phone VARCHAR(10) NOT NULL UNIQUE,
    delivery_address  VARCHAR(150) NOT NULL
  )

-- Create Item Types Table
  use washshop
  CREATE TABLE item_types(
    id INT IDENTITY PRIMARY KEY NOT NULL,
    item_type VARCHAR(30) NOT NULL,
    wash_price SMALLINT NOT NULL
  )

-- Create the Orders table
use washshop
CREATE TABLE orders(
  id INT IDENTITY PRIMARY KEY NOT NULL,
  batchID VARCHAR(15) NOT NULL,
  customer_id INT NOT NULL,
  item_type INT NOT NULL,
  paid VARCHAR(3) NOT NULL CHECK(paid IN ('Yes', 'No')),
  completed VARCHAR(3) NOT NULL CHECK(completed IN ('Yes', 'No')),
  collected VARCHAR(3) NOT NULL CHECK (collected IN ('Yes', 'No')),
  CONSTRAINT  FK_orders_customer_id FOREIGN KEY (customer_id) REFERENCES customers(id),
  CONSTRAINT FK_orders_item_type FOREIGN KEY (item_type) REFERENCES item_types(id)
)
