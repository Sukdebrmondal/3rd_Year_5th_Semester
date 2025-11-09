
a = 581
b=abs(a)
s = 0
num=str(b)
for i in range(len(num)):  
    if (i+1)%2==0:
        s=s+int(num[i])
        # s=s+i
        print(s)

interst=str(s)
print("the result is: " + interst)