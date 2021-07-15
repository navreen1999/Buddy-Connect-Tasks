select *from Products
select *from PurchaseOrderDetails
select *from PurchaseOrders
select *from Customers

--1--
select c.CustomerName,po.PurchaseOrderId,p.ProductName,pod.Price
from Customers c join PurchaseOrders po
on c.CustomerID=po.CustomerID
join PurchaseOrderDetails pod on 
po.PurchaseOrderId=pod.PurchaseOrderID
join Products p
on p.ProductID=pod.ProductID

--2--

select MONTH(po.Date),c.CustomerName,SUM(po.Amount)
from Customers c join PurchaseOrders po
on c.CustomerID=po.CustomerID
group by MONTH(po.Date),c.CustomerName


select p.ProductName,MONTH(po.Date) MonthOfPurchase,SUM(pod.Quantity) Quantity
from Products p join PurchaseOrderDetails pod
on p.ProductID=pod.ProductID
join PurchaseOrders po on
po.PurchaseOrderID=pod.PurchaseOrderID
group by MONTH(po.Date),p.ProductName 
order by p.ProductName

select MONTH(po.Date),YEAR(po.Date),pod.PurchaseOrderID,MAX(pod.Price)
from PurchaseOrderDetails pod join
PurchaseOrders po on
pod.PurchaseOrderID=po.PurchaseOrderId
group by pod.PurchaseOrderID,MONTH(po.Date),YEAR(po.Date)
