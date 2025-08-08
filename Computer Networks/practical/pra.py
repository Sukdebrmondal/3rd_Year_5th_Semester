import socket


def server_program():
    host=socket.gethostname() #local host server
    port=6000   #same port number
    print("local host name is: " + host, "and port number is: ",port)

    #create server socker using TCP protocol
    server_socket=socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server_socket.bind ((host, port))    #binds host and port together
    print("server is listening for incoming conections...")

    server_socket.listen(1)

    connection,address=server_socket.accept() #accept new connection

    print("connection from" + address)
    print("connection from" + connection)


    while True:
        data=connection.recv(1024).decode()
        if not data:
            break
        print("from connected user: " +str(data))

        data=input("send the messege to the client: ")
        connection.send(data.encode()) #sends the data to the server
        
    connection.close()




if __name__ == "__main__" :
    server_program()