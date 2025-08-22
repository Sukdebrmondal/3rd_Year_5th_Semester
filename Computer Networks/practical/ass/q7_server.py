import socket
import os

def server_program():
    host=socket.gethostname()
    port=5000

    server_socket=socket.socket(socket.AF_INET,socket.SOCK_STREAM)
    server_socket.bind((host,port))
    server_socket.listen()
    conn,address=server_socket.accept()
    print("the conncetion client: " + str(address))

    data=conn.recv(1024).decode()
    filename,block_size=map(str,data.split(","))
    

if __name__ == "__main__":
    server_program()