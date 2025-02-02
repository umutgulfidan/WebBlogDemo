Create Trigger AddScoreInComments
on Comments
After Insert
As
Declare @ID int
Declare @Score int
Declare @RatingCount int
Select @ID = BlogID, @Score = BlogScore from inserted
Update BlogsRatings Set BlogTotalScore += @Score , BlogRatingCount +=1
where BlogID = @ID