--1.List all cities that have both Employees and Customers.
select distinct e.city from Employees e inner join customers c on e.city = c.city

--2List all cities that have Customers but no Employee.
--a.      Use sub-query
select e.city from employees e 

select distinct c.city from customers c where c.city not in (select e.city from employees e )

--b.      Do not use sub-query
select distinct c.city from customers c left join employees e on c.city = e.city where e.city is null


--3.  List all products and their total order quantities throughout all orders.
select * from Customers 
select * from orders 
select * from [Order Details]
select p.ProductName, sum(od.Quantity) as qty  from products p inner join [Order Details] od on p.ProductID=od.ProductID group by p.ProductName order by qty desc
--4.  List all Customer Cities and total products ordered by that city.
select c.city, sum(od.quantity) as qty from customers c join orders o on c.CustomerID=o.CustomerID
join [Order Details] od on o.orderid = od.orderid 
group by c.city order by qty desc


--5. List all Customer Cities that have at least two customers.
--a.      Use union
select distinct c1.city from customers c1 join customers c2 on c1.city =c2.city and c1.customerid <> c2.CustomerID
union
select distinct c2.city from customers c2 join customers c1 on c1.city =c2.city and c1.customerid <> c2.CustomerID


--b.      Use sub-query and no union
 select distinct c.city  from customers c
 where (SELECT COUNT(*)
    FROM Customers c
    WHERE City = c.City)>=2


--6.List all Customer Cities that have ordered at least two different kinds of products.

SELECT c.City, count(distinct p.productid) as products
FROM Customers c
JOIN Orders o 
    ON c.CustomerID = o.CustomerID
JOIN [Order Details] od 
    ON o.OrderID = od.OrderID
JOIN Products p 
    ON od.ProductID = p.ProductID
group by c.city
having count(distinct p.productid) >= 2

--7. List all Customers who have ordered products, but have the ‘ship city’ on the order different from their own customer cities.

SELECT distinct c.City, o.ShipCity, c.CustomerID
FROM Customers c
JOIN Orders o 
    ON c.CustomerID = o.CustomerID
where c.city <> o.ShipCity

--8. List 5 most popular products, their average price, and the customer city that ordered most quantity of it.

select tc.productid, p.productname, tc.avgp, tc.tqy, 
(select top 1 c.city from [Order Details] od join orders o on od.OrderID=o.OrderID join Customers c on o.CustomerID=c.CustomerID where od.ProductID=tc.productid group by c.city order by sum(od.quantity) desc
) as topcity
from
(select top 5 od.productid, sum(Quantity) as tqy, avg(UnitPrice) as avgp from [Order Details] od group by ProductID order by sum(Quantity) desc) tc
join products p on tc.productid=p.productid order by 4 desc

--9.List all cities that have never ordered something but we have employees there.
--a.      Use sub-query
select e.city from employees e
where e.city not in (
select distinct c.city from customers c
)

--b.      Do not use sub-query
select distinct e.city from employees e 
except
select distinct c.city from customers c
-- 9. Cities with employees but no customer orders (no subquery)
select distinct e.city from employees e 
except
select distinct c.city from customers c join orders o on c.customerid=o.customerid

--10.List one city, if exists, that is the city from where the employee sold most orders (not the product quantity) is, and also the city of most total quantity of products ordered from. (tip: join  sub-query)
select co.city as mostorders, ct.city as mostquantity from (select top 1 e.city, count(o.orderid) as orders from employees e join orders o on e.EmployeeID=o.EmployeeID group by e.city order by count(o.orderid) desc
) co
cross join 
(
select top 1 c.city, sum(od.quantity) as tqy from customers c join orders o on c.customerid=o.customerid join [Order Details] od on o.orderid=od.orderid group by c.city order by sum(od.quantity) desc
) ct 
--11.How do you remove the duplicates record of a table?
-- using distinct
