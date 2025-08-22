# Develop a client-Server application using TCP where the client will send two file names to 
# the server and the server will copy the content of the first file into the second file. After 
# copying is done, the server will send an appropriate message to the client. The second file 
# should be initially empty. Assume that both files are present at the server. 

import socket
import os

def server_program():
    host=socket.gethostname()  # get the hostname
    port=5000  # initiates port no above 1024

    print("-->" + host)

    server_socket=socket.socket(socket.AF_INET,socket.SOCK_STREAM) # creates server side socket
    server_socket.bind((host,port))  # binds host address and port together

    server_socket.listen() # how many client the server can listen simultaneously
    conn,address=server_socket.accept() # accepts new connection
    print("the connection cllient: " + str(address))

    
    data=conn.recv(1024).decode()
    file1,file2=map(str,data.split(","))  #data split
    print(file1,file2)

    try:
        if (os.path.exists(file1) and os.path.exists(file2)):
            f = open(file1,"r")
            content = f.read()
            f.close()
            e = open(file2,'w')
            e.write(content)
            c="content copied successfully!!"
            e.close()
        else:
            c="not found"
    except Exception as e:
        print(e)

    print("The condition check from the server side: " + c)
    conn.send(c.encode()) #send to the client
    conn.close()

if __name__ == "__main__":
    server_program()