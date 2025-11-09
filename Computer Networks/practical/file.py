file1 = "test1.txt"
file2 = "test2.txt"


f = open(file1,"r")
content = f.read()

f.close()


e = open(file2,'w')
e.write(content)

e.close()