import socket
import os
def server_program():
    host = socket.gethostname() #local host
    port = 5000
    print("->" + host)

    # socket create
    server_socket = socket.socket(socket.AF_INET,socket.SOCK_DGRAM)

    # connection
    server_socket.bind((host, port))
    print("UDP Server running.....")

    while True:
        data,address = server_socket.recvfrom(1024)
        print("data: ", data)
        print("Address: ", address)
        file = data.decode()
        print(file)
        if file.lower().strip() == "exit":
            print("Server shutting down.")
            break
        
        if os.path.exists(file):
            f=open(file, "r")
            content = f.read()
            print("the content of this file: " + content)
            server_socket.sendto(content.encode(), address)
        else:
            message = "File does not exist on the server"
            server_socket.sendto(message.encode(), address)
            

    server_socket.close()


if __name__ == '__main__':
    server_program()



# ->SUKDEB
# UDP Server running.....
# data:  b'test1.txt'
# Address:  ('10.142.105.6', 59026)
# test1.txt
# the content of this file: hi there this  a test1 file content....

# data:  b'text.txt'
# Address:  ('10.142.105.6', 59026)
# text.txt
# data:  b'exit'
# Address:  ('10.142.105.6', 59026)
# exit
# Server shutting down.