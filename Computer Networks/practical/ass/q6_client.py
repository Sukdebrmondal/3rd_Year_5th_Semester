# Develop a client-Server application using TCP where the client will send two file names to 
# the server and the server will copy the content of the first file into the second file. After 
# copying is done, the server will send an appropriate message to the client. The second file 
# should be initially empty. Assume that both files are present at the server.

import socket

def client_program():
    host=socket.gethostname()  # get the hostname
    port=5000 # socket server port number

    print("Client is starting on host:", host)

    client_socket=socket.socket(socket.AF_INET,socket.SOCK_STREAM) # creates client side socket
    client_socket.connect((host,port)) # connects to the server
    while True:

        # takes input
        a=input("enter the first file: ")
        if not a:
            print("client exiting.....")
            break
        b=input("enter the second file: ")

        message=f"{a},{b}"
        client_socket.send(message.encode()) # sends message

        data=client_socket.recv(1024).decode()  # receives response
        print("The condition check from the client side: " + data) #print
        print("\n")
    client_socket.close()

if __name__ == '__main__':
    client_program()


# Client is starting on host: SUKDEB
# enter the first file: test1.txt
# enter the second file: test2.txt
# The condition check from the client side: Content copied successfully!!


# enter the first file: 
# client exiting.....