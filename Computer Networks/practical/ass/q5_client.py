# Develop a client-Server application using TCP where the client will send two words to the 
# server and the server will check whether same characters are present in both the words and 
# they occur same number of times (irrespective of position of the characters) and send back 
# the result to the client. The client will display the result. 
# [Example: Input: listen silent, Output: Check condition satisfied.] 

import socket

def client_program():
    host=socket.gethostname()  # get the hostname
    port=5000 # socket server port number
    print("Client is starting on host:", host)
    client_socket=socket.socket(socket.AF_INET,socket.SOCK_STREAM) # creates client side socket
    client_socket.connect((host,port)) # connects to the server

    while True:
        a=input("enter the first word: ")
        if not a:
            print("Client exiting...")
            break
        b=input("enter the second word: ")

        message=f"{a},{b}"
        client_socket.send(message.encode()) # sends message

        data=client_socket.recv(1024).decode()  # receives response
        print("The condition check from the server side: " + data) #print
        print("\n")
    client_socket.close()

if __name__ == '__main__':
    client_program()


# Client is starting on host: SUKDEB
# enter the first word: listen
# enter the second word: silent
# The condition check from the server side: Check condition satisfied


# enter the first word: sukdeb
# enter the second word: bedkus
# The condition check from the server side: Check condition satisfied


# enter the first word: hello
# enter the second word: hi
# The condition check from the server side: Check condition not satisfied


# enter the first word:
# Client exiting...