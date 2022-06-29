# CoffeShop README.md
Change the Connection string in CoffeeShop/Web.config 

You can see in MS SQL Server Managment, like this "LAPTOP-IDFPTM4U\SQLEXPRESS"

Then replace by yours
>![ConnectionString](https://user-images.githubusercontent.com/93419674/176346599-6b5c60a9-ad28-4773-aba0-8528caba3efb.jpg)
>
>Quickly, use the command prompt: Press Windows+R, then type 'CMD' in the box. Click OK > type 'hostname' > press Enter.

Change the path of the Image in the configuration file in Coffeshop Database (CoffeShopDatabase/Migrations/Configuration.cs)
>![Config](https://user-images.githubusercontent.com/93419674/176351750-0f01490f-6bf8-4c5d-88ef-d423e758fc28.jpg)

Also change this (Services/SignUp.cs)
>![Config2](https://user-images.githubusercontent.com/93419674/176351764-05d4aac2-5910-486f-ab52-c367f0f7dfa1.jpg)

Run "update-database" in Package manager console
>![updatedatabase](https://user-images.githubusercontent.com/93419674/176347236-4d67f307-aec5-4bec-95ec-9e5e09842126.jpg)
>Remmeber to change Default project to "CoffeshopDatabase"
