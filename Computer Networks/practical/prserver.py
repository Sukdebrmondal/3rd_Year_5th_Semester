import socket

def server_program():

    host=socket.gethostname()
    port=5000

    print("-->" + host)
    print(port)

    server_socket = socket.socket(socket.AF_INET,socket.SOCK_STREAM) #socket create

    server_socket.bind((host,port))

    server_socket.listen(2)

    connection,address = server_socket.accept()
    print("connection from-->" + str(address))

    while True:
        data=connection.recv(1024).decode() #data receive
        if not data:
            break
        print("the connection user: " + str(data)) #print data from the client

        message=input("-->")

        connection.send(message.encode())
        
    connection.close()
    

if __name__ == '__main__':
    server_program()