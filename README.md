# ASPCoreMay2020
ASP.NET Core 3.1 khai giảng 10.05.2020


## Loading all data
ctx.HangHoas.ToList()
ctx.HangHoas.ToListAsync()

## Loading a single entity
ctx.HangHoas.SingleOrDefault(LINQ condition))

LINQ dạng obj => obj

## Filtering (lọc)
var result = ctx.HangHoas.Where(LINQ condition)

Để kiểm tra kết quả lọc
nên sử dụng: result.Any()
không nên: result.Count() > 0

----------------
LINQ Query (chỉ cần mảng các phần tử)
# Query syntax
from obj in objList
where <condition>
select obj;

# Lamda syntax
objList.Where(p => p....)

## Sắp xếp
 result.OrderBy(p => p.ColumnA)
 result.OrderByDescending(p => p.ColumnB)
 result.OrderBy(p => p.ColumnA).ThenBy(p => p.ColumnB)

## Gom nhóm
result.GroupBy(p => p.Column)







