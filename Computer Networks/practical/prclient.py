import socket

def client_program():
    host=socket.gethostname()
    port=5000
    # print("-->" + host)
    # print(port)

    client_socket=socket.socket(socket.AF_INET,socket.SOCK_STREAM)

    client_socket.connect((host,port))

    message=input("--->")

    while message.lower().strip()!='exit':
        client_socket.send(message.encode())

        data=client_socket.recv(1024).decode()

        print("the server side: " + data)

        message=input("--->")

    client_socket.close()


if __name__ == '__main__':
    client_program()