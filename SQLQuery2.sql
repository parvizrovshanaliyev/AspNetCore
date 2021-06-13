-- select

select * from Customers

select * from Customers where Customers.City='Berlin'

-- case insensitive or and

select * from Products where CategoryID=1 or CategoryID=3
select * from Products where CategoryID=1 and UnitPrice >= 10

-- order by

select * from Products order by ProductName
select * from Products order by UnitPrice asc -- ascending (artan sira ile)
select * from Products order by UnitPrice desc -- descendinf (azalan sira ile)

select count(*) from Products

-- group by

select CategoryID, count(*) from Products group by CategoryID
-- icerisinde 10-dan az product olanlar
select CategoryID, count(*) from Products group by CategoryID having count(*)<10