
# Develop a client-server application using TCP where the client sends the name of a text file 
# and the size of the block of data to the server, the server checks the availability of the text 
# file and if the text file is available, sends the text file content to the client as per the input 
# block size after reading the file contents. After sending the whole file, display an appropriate 
# message. 

import socket

#------
# check error
#------


def client_program():
    host=socket.gethostname()
    port=5000
    print("Client is starting on host:", host)
    client_socket=socket.socket(socket.AF_INET,socket.SOCK_STREAM)
    client_socket.connect((host,port))
    print("client side start........")
    while True:
        filename = input("Enter the filename: ")
        if not filename:
            print("Client exiting.....")
            break
        block_size = input("Enter block size (number of bytes): ")

        message=f"{filename},{block_size}"
        client_socket.send(message.encode())
        data=client_socket.recv(1024).decode()
        print("The condition check from the server side: " + data)
        print("\n")
    client_socket.close()

if __name__ == "__main__":
    client_program()


# Client is starting on host: SUKDEB
# client side start........
# Enter the filename: test1.txt
# Enter block size (number of bytes): 5
# The condition check from the server side: hi th


# Enter the filename: test1.txt
# Enter block size (number of bytes): 7
# The condition check from the server side: hi ther


# Enter the filename: 
# Client exiting.....