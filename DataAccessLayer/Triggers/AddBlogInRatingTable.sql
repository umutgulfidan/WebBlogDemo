Create Trigger AddBlogInRatingTable
on Blogs
After Insert
As
Declare @ID int 
Select @ID=BlogID from inserted
Insert into BlogsRatings(BlogID,BlogRatingCount,BlogTotalScore)
Values (@ID,0,0)