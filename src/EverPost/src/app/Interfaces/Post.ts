export interface Post{
    PostId:number,
    UserId:number, 
    Title:string,
    Description:string,
    DateCreated:string | Date, 
    Status:string,
    TotalComments:number, 
    ImageRoute:string
}