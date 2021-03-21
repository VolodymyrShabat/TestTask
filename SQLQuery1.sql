/*Select product with product name that begins with ‘C’. */Select *from Products where Products.ProductName like 'C%'/*Select product with the smallest price. */SELECT * 
FROM Products 
WHERE Price IN 
( SELECT Min(Price)
  FROM Products
)

/*Select cost of all products from the USA. */
Select Sum(Price)
from Products join Suppliers on (Products.SuppllerID = Suppliers.SuppllerID )
Where Country='USA'


/*Select suppliers that supply Condiments */

/*First way */
Select *
From Suppliers 
Where SuppllerID in
(
	Select SuppllerID 
	from Products
	where CategoryID IN
	(
		Select CategoryID
		FROM Categories
		where CategoryName='Condiments'
		)
)

/*Second way */
Select Distinct Products.SuppllerID,SuppllerName,City,Country
from Products join Suppliers on (Products.SuppllerID = Suppliers.SuppllerID) join Categories on (Products.CategoryID = Categories.CategoryID)
where CategoryName = 'Condiments'





/*Add to database new supplier with name: ‘Norske Meierier’, city: ‘Lviv’, country: ‘Ukraine’ which
will supply new product with name: ‘Green tea’, price: 10, and related to category with name:
‘Beverages’. */
Insert into Suppliers
values
(6,'Norske Meierier', 'Lviv', 'Ukraine')

DECLARE @SupID as int
Select @SupID = SuppllerId from Suppliers where SuppllerName='Norske Meierier';
PRINT @SupID

DECLARE @CatID as int
Select @CatID = CategoryID From Categories where CategoryName = 'Beverages'
PRINT @CatID


Insert into Products 
values(6,'Green tea',@SupID,@CatID,10.00)