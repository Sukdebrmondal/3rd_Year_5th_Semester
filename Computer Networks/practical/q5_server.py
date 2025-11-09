# Develop a client-Server application using TCP where the client will send two words to the 
# server and the server will check whether same characters are present in both the words and 
# they occur same number of times (irrespective of position of the characters) and send back 
# the result to the client. The client will display the result. 
# [Example: Input: listen silent, Output: Check condition satisfied.] 

import socket

def server_program():
    host=socket.gethostname()  # get the hostname
    port=5000  # initiates port no above 1024

    print("Server is starting on host:", host)

    server_socket=socket.socket(socket.AF_INET,socket.SOCK_STREAM) # creates server side socket
    server_socket.bind((host,port))  # binds host address and port together

    server_socket.listen() # how many client the server can listen simultaneously
    conn,address=server_socket.accept() # accepts new connection
    print("the connection cllient: " + str(address))

    while True:
        data=conn.recv(1024).decode()
        if not data:
            print("Server shutting down.")
            break
        a,b=map(str,data.split(","))  #data split
        c=""
        if sorted(a) == sorted(b):  #check the condition
            c="Check condition satisfied"
        else:
            c="Check condition not satisfied"

        print("The condition check result: " + c)
        print("\n")
        message=c
        conn.send(message.encode()) #send to the client
    conn.close()

if __name__ == "__main__":
    server_program()


# Server is starting on host: SUKDEB
# the connection cllient: ('10.142.105.6', 58806)
# The condition check result: Check condition satisfied


# The condition check result: Check condition satisfied


# The condition check result: Check condition not satisfied


# Server shutting down.