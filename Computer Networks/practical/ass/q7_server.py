import socket
import os

def server_program():
    host=socket.gethostname()
    port=5000
    print("Server is starting on host:", host)
    server_socket=socket.socket(socket.AF_INET,socket.SOCK_STREAM)
    server_socket.bind((host,port))
    server_socket.listen()
    conn,address=server_socket.accept()
    print("server side start........")
    print("the conncetion client: " + str(address))
    while True:
        data=conn.recv(1024).decode()
        if not data:
            print("Server shutting down.")
            break
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
        print("\n")
        conn.send(content.encode())
    server_socket.close()

if __name__ == "__main__":
    server_program()


# Server is starting on host: SUKDEB
# server side start........
# the conncetion client: ('10.142.105.6', 64501)
# test1.txt,5
# test1.txt
# The condition check from the server side: hi th


# test1.txt,7
# test1.txt
# The condition check from the server side: hi ther


# Server shutting down.