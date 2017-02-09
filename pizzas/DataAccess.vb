﻿Public Class DataAccess
    Dim Sql As DBconnect
    Public dt As New DataTable

    Public Function InsertEmployeeDetails(fname As String, lname As String, phone As String, email As String, reportsTo As Integer, deptid As Integer, bdate As Date, hiredate As Date, adtype As String, addline As String, city As String, zip As Integer) As Integer
        Sql = New DBconnect()
        Dim insertEmpStr As String
        Dim insAddrStr As String
        Dim InsertSuccess As Integer
        insertEmpStr = "INSERT INTO employee (`Firstname`,`Lastname`,`Phone`,`Email`,`ReportsTo`,`department_id`,`Birthdate`,`hire_date`) VALUES ('" & fname & "','" & lname & "','" & phone & "', '" & email & "','" & reportsTo & "', '" & deptid & "', '" & bdate.ToString("yyyy-MM-dd hh:mm:ss") & "', '" & hiredate.ToString("yyyy-MM-dd hh:mm:ss") & "' )"
        insAddrStr = "INSERT INTO address(`Address_type`,`Address_line1`,`City`,`Zip`) values ('" & adtype & "', '" & addline & "', '" & city & "', '" & zip & "')"
        InsertSuccess = Sql.ExecuteInsUpdDel(insertEmpStr, True) REM True, it is Insert
        InsertSuccess = Sql.ExecuteInsUpdDel(insAddrStr, True)
        Return InsertSuccess
    End Function
    Public Function GetEmpViewDetails(empid As String) As DataTable
        Sql = New DBconnect()
        Dim selectStr As String
        selectStr = "SELECT * from employee where employee_id = '" & empid & "'"
        Dim dt As DataTable = Sql.ExecuteSelectTable(selectStr)
        Return dt
    End Function

    Public Function UpdateEmpDetails(empid As Integer, fname As String, lname As String, phone As String, email As String, reportsTo As Integer, deptid As Integer) As Integer
        Sql = New DBconnect()
        Dim insertStr As String
        Dim InsertSuccess As Integer
        insertStr = "Update employee set Firstname='" & fname & "',Lastname = '" & lname & "',Phone = '" & phone & "',Email = '" & email & "',ReportsTo = ' " & reportsTo & "',department_id = '" & deptid & "' where employee_id = '" & empid & "'"
        InsertSuccess = Sql.ExecuteInsUpdDel(insertStr, True)
        Return InsertSuccess
    End Function
    Public Function GetAllEmpDetails() As DataTable
        Sql = New DBconnect()
        Dim selectStr As String
        selectStr = "SELECT * from employee"
        Dim dt As DataTable = Sql.ExecuteSelectTable(selectStr)
        Return dt
    End Function
    Public Function GetEmpId() As DataTable
        Sql = New DBconnect()
        Dim selectStr As String
        selectStr = "SELECT employee_id from employee order by employee_id desc limit 1"
        Dim dt As DataTable = Sql.ExecuteSelectTable(selectStr)
        Return dt
    End Function
    Public Function DeleteEmp(empid As String) As DataTable
        Sql = New DBconnect()
        Dim selectStr As String
        selectStr = "Delete from employee where employee_id = '" & empid & "'"
        'employee_id,Firstname,Lastname,Phone,Email,department_id
        Dim dt As DataTable = Sql.ExecuteSelectTable(selectStr)
        Return dt
    End Function
    Public Function GetAboutEmp() As DataTable
        Sql = New DBconnect()
        Dim selectStr As String
        selectStr = "select * from managerviewsemployeedetails"
        Dim dt As DataTable = Sql.ExecuteSelectTable(selectStr)

        Return dt
    End Function
    Public Function GetSales() As DataTable
        Sql = New DBconnect()
        Dim selectStr As String
        selectStr = "select * from posreport"
        Dim dt As DataTable = Sql.ExecuteSelectTable(selectStr)

        Return dt
    End Function
    Public Function GetSalesInlastThreeMonths() As DataTable
        Sql = New DBconnect()
        Dim selectStr As String
        selectStr = "select * from salesreportbymonth"
        Dim dt As DataTable = Sql.ExecuteSelectTable(selectStr)

        Return dt
    End Function
    Public Function GetInventory() As DataTable
        Sql = New DBconnect()
        Dim selectStr As String
        selectStr = "select * from inventryreport"
        Dim dt As DataTable = Sql.ExecuteSelectTable(selectStr)

        Return dt
    End Function
    Public Function GetPizzaswithRMlessInStock() As DataTable
        Sql = New DBconnect()
        Dim selectStr As String
        selectStr = "select * from itemshavingrawmaterialslessthanstockminlevel"
        Dim dt As DataTable = Sql.ExecuteSelectTable(selectStr)

        Return dt
    End Function
    Public Function UserExists(ByVal userId As String) As Boolean
        Dim exists As Boolean

        exists = userId IsNot Nothing

        Return exists
    End Function
    Public Function CreatPO(RmId As Integer, RmQnty As Integer, vendorId As Integer, poDate As Date, PODelDate As Date, EmpId As Integer) As Integer
        Sql = New DBconnect()
        Dim insertEmpStr As String
        Dim InsertSuccess As Integer
        insertEmpStr = "insert into purchaseorder(`rawmaterial_id`,`rawmaterial_quantity`,`vendor_id`,`PO_date`,`PO_deliverydate`,`Employee_id`) values('" & RmId & "','" & RmQnty & "','" & vendorId & "', '" & poDate & "', '" & PODelDate & "', '" & EmpId & "');"
        InsertSuccess = Sql.ExecuteInsUpdDel(insertEmpStr, True) REM True, it is Insert
        Return InsertSuccess
    End Function
    Public Function GetPoReort() As DataTable
        Sql = New DBconnect()
        Dim selectStr As String
        selectStr = "select * from AmountOnPObvndors"
        Dim dt As DataTable = Sql.ExecuteSelectTable(selectStr)
        Return dt
    End Function
    Public Function GetAllPO() As DataTable
        Sql = New DBconnect()
        Dim selectStr As String
        selectStr = "select * from purchaseorder"
        Dim dt As DataTable = Sql.ExecuteSelectTable(selectStr)

        Return dt
    End Function

End Class
