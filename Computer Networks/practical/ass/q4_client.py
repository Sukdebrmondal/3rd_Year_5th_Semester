# Develop a client-server application using TCP where the client will send two operands and 
# an operator to the server in operand1 operator operand2 format and the server will calculate 
# the result and display it. Allowed operators are +, -, *, /, %. 

import socket

def client_program():
    host=socket.gethostname()  # get the hostname
    port=5000 # socket server port number

    client_socket=socket.socket(socket.AF_INET,socket.SOCK_STREAM)  #create client side socket
    client_socket.connect((host,port))  # connects to the server
    while True:
        a=input("enter the number1: ")  #takes inputs
        if a == "exit":   
            break
        b=input("enter the number2: ")
        c= input("enter the operator: ") 
         
        #all input write in a single string
        message= f"{a},{b},{c}"
        client_socket.send(message.encode()) #data data to the server
        data=client_socket.recv(1024).decode() #receive from the server
        print("Result show from the client side: " + data) #show result
    client_socket.close()

if __name__ == '__main__':
    client_program()