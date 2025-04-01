export interface Comment {
    commentId: number;  
    content: string;
    postId?: number;  
    status: string;   
    userId: number;  
    dateCreated: Date; 
  }