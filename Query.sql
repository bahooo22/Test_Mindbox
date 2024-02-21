SELECT p.product_name, COALESCE(c.category_name, 'Без категории') AS category_name
FROM products p
LEFT JOIN product_categories pc ON p.product_id = pc.product_id
LEFT JOIN categories c ON pc.category_id = c.category_id