
# Get current stock
GET /v1/ingredients?select=Name,Quantity

# Get address and date for order
GET /v1/orders/{id}?select=DeliveryPlace,DeliveryDate

# Get list of baked goods in an order
GET /v1/orders/{id}/baking_goods

# Get ingredients for a batch
GET /v1/batches/{id}/ingredients

# Get trackids for an order
GET /v1/orders/{id}/packets

# Get quantities of each baking goods in all orders
GET /v1/baking_goods?select=Name,TotalQuantityOrdered

# Get average delay for all batches
GET /v1/batches/average_delay

## DATA QUERIES

## 1. Get the current stock
SELECT name, quantity
FROM ingredient;

## 2. Get the address and date for an order
SELECT o.delivery_place, o.delivery_date
FROM [order] o
WHERE o.order_id = 1;

## 3. Get the list of baked goods in an order
SELECT bg.name, p.amount
FROM baking_good bg
INNER JOIN part_of p ON bg.baking_good_id = p.baking_good_id
WHERE p.order_id = 2;

## 4. Get the ingredients for a batch
SELECT i.name, c.amount * b.quantity AS total_amount
FROM ingredient i
INNER JOIN consists c ON i.ingredient_id = c.ingredient_id
INNER JOIN batch b ON c.baking_good_id = b.baking_good_id
WHERE b.batch_id = 2;

## 5. Get the track ids corresponding to an order
SELECT p.track_id
FROM packet p
WHERE p.order_id = 1;

## 6. Produce a table containing the quantities of each baking goods in all the orders received so far
SELECT bg.name, SUM(p.amount) AS total_quantity
FROM baking_good bg
INNER JOIN part_of p ON bg.baking_good_id = p.baking_good_id
GROUP BY bg.name
ORDER BY bg.name ASC;

## 7. Get the average delay for all the batches
SELECT AVG(DATEDIFF(MINUTE, b.target_finish_time, b.actual_finish_time)) AS average_delay_minutes
FROM batch b;

