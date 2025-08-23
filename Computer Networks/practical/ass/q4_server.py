# Develop a client-server application using TCP where the client will send two operands and 
# an operator to the server in operand1 operator operand2 format and the server will calculate 
# the result and display it. Allowed operators are +, -, *, /, %. 

import socket

def server_program():
    host=socket.gethostname() # get the hostname
    port=5000   # initiates port no above 1024

    print("-->" + host)

    server_socket = socket.socket(socket.AF_INET,socket.SOCK_STREAM) # creates server side socket

    server_socket.bind((host,port))  # binds host address and port together

    server_socket.listen() # how many client the server can listen simultaneously

    connection,address = server_socket.accept() # accepts new connection

    print("the connction client: " + str(address))
    while True: 
        # receive data from the client
        data=connection.recv(1024).decode()
        if data == "exit":
            print("Server shutting down.")
            break

        # split the string
        a,b,c=map(str,data.split(",")) 
        a=int(a)
        b=int(b)

        # operation
        res=0
        if( c == "+"):
            res=a+b
        elif( c == "-"):
            res=a-b
        elif( c == "*"):
            res=a*b
        elif( c == "/"):
            res=a/b
        else:
            print("wrong!")

        message=str(res)
        # show the result
        print("Result show from the server side: " + message)
        connection.send(message.encode()) #send the result to the client
    connection.close()

if __name__ == '__main__':
    server_program()