;#DropDB DemoComprenhesiveEasyTest

#Application DemoComprenhesive.Win
#Application DemoComprenhesive.Web

*FillForm
 User Name = Admin
*Action Log In

#IfDef DemoComprenhesive.Win

*Action About...
 
*Action OK

#EndIf

#IfDef DemoComprenhesive.Web
*Action Navigation(My Details)
#EndIf
