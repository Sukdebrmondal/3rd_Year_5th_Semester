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
    print(data)
    file,block_size=map(str,data.split(","))
    print(file)

    try:
        if(os.path.exists(file)):
            f=open(file,"r")
            content=f.read(int(block_size))
            f.close()
    except Exception as e:
        print(e)
    print("The condition check from the server side: " + content)
    conn.send(content.encode())
    conn.close()

if __name__ == "__main__":
    server_program()