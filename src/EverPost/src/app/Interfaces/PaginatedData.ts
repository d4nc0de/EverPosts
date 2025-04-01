export interface PaginatedData<T> {
    data: T[];
    totalRecords: number;
    page: number;
    pageSize: number;
    totalPages: number;
}