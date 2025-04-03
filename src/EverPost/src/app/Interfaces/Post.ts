export interface Post{
    postId:number,
    userId:number, 
    title:string,
    description:string,
    dateCreated:string | Date, 
    status:string,
    totalComments:number, 
    imageRoute:string
}