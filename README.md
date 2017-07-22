# MongoDb 
This project will depict how to use MongoDb a document database. 
@sunnysinghdev :+1: 
> This page is for documentation of MongoDb client usage

## Connection String For Mongo Client

```
mongodb://<USER>:<PASSWORD>@cluster-0-shard-00-00-kmsg7.mongodb.net:27017,cluster-0-shard-00-01-kmsg7.mongodb.net:27017,cluster-0-shard-00-02-kmsg7.mongodb.net:27017/<DATABASE>?ssl=true&replicaSet=Cluster-0-shard-0&authSource=admin
```
## MongoDB Shell

1. Command to connect Mongo Atlas cloud
```
mongo "mongodb://cluster-0-shard-00-00-kmsg7.mongodb.net:27017,cluster-0-shard-00-01-kmsg7.mongodb.net:27017,cluster-0-shard-00-02-kmsg7.mongodb.net:27017/test?replicaSet=Cluster-0-shard-0" --authenticationDatabase admin --ssl --username atlas_gladbeak --password <PASSWORD>
```

2. Start MongoDb Local
```
c:\mongodb\bin>mongod -- directoryperdb --dbpath D:\mongodb\data\db --logpath D:\mongodb\log\mongo.log --rest --install
```
```
net start MongoDB
```

3. To use local database type only
```
mongo
```

4. Basic operations in mondodb. _use four spaces to indent_
    1. To Create or Use database type 
       ```
       use contacts;
       ```
    2. To Create user type
       ``` 
       db.createUser({
	    user:"admin",
	    pwd:"admin",
	    roles:["readWrite", "dbAdmin"]
       });
       ```
    3. To Create a table Collection type
       ```
       db.createCollection("mycontacts"); 
       ```
    4. To insert single record
	```
	db.mycontacts.insert(
	{
		first_name:"Sunny",
		last_name:"Singh",
		age:28
	});
	```
    5. To insert multiple records
	```
	db.mycontacts.insert(
	[
		{
			first_name:"Ashish",
			last_name:"Singh",
			age:12
		},
		{
			first_name:"Ravi",
			last_name:"Singh",
			age:12,
			marital:"married"
		},	
	]);
	```
