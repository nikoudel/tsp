This project compares performance of a brute-force
algorithm solving Travelling Salesman Problem
implemented in .NET, Go and C. Go seems to be the
most efficient in this particular task.
 
.NET:

length: 1476,46685102227
path: 5-0-1-3-2-4-7-8-6-9
time (sec): 13,0837483

length: 1476,46685102227
path: 5-0-1-3-2-4-7-8-6-9
time (sec): 12,7907316

length: 1476,46685102227
path: 5-0-1-3-2-4-7-8-6-9
time (sec): 12,9087383

length: 1601,49356425133
path: 0-1-3-2-4-7-10-8-6-9-5
time (sec): 159,2611092

length: 1601,49356425133
path: 0-1-3-2-4-7-10-8-6-9-5
time (sec): 156,1882602

Go:

length: 1476.4668510222727
path: 5-0-1-3-2-4-7-8-6-9
time: 7.4326234s

length: 1476.4668510222727
path: 5-0-1-3-2-4-7-8-6-9
time: 7.3840215s

length: 1476.4668510222727
path: 5-0-1-3-2-4-7-8-6-9
time: 7.4090229s

length: 1601.4935642513287
path: 0-1-3-2-4-7-10-8-6-9-5
time: 1m29.0442914s (89s)

length: 1601.4935642513287
path: 0-1-3-2-4-7-10-8-6-9-5
time: 1m29.1686993s (89s)

C:

length: 1476.466851
path: 5-0-1-3-2-4-7-8-6-9
time (sec): 7.581000

length: 1476.466851
path: 5-0-1-3-2-4-7-8-6-9
time (sec): 7.519000

length: 1476.466851
path: 5-0-1-3-2-4-7-8-6-9
time (sec): 7.488000

length: 1601.493564
path: 0-1-3-2-4-7-:-8-6-9-5
time (sec): 108.342000

length: 1601.493564
path: 0-1-3-2-4-7-:-8-6-9-5
time (sec): 108.373000