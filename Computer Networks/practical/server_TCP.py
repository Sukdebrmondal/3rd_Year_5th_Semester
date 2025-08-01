import socket


def server_program():
    
    host = socket.gethostname() # get the hostname
    port = 5000  # initiates port no above 1024
    print("->" + host)

    server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)  # creates server side socket
    
    server_socket.bind((host, port))  # binds host address and port together

    server_socket.listen(2)  # how many client the server can listen simultaneously
    conn, address = server_socket.accept()  # accepts new connection
    
    print("Connection from: " + str(address))
    while True:
        # receives data stream. it won't accept data packet greater than 1024 bytes
        data = conn.recv(1024).decode()
        if not data:
            # if data is not received then break
            break
        print("from connected user: " + str(data))
        data = input(' -> ')
        conn.send(data.encode())  # sends data to the client

    conn.close()  # closes the connection


if __name__ == '__main__':
    server_program()