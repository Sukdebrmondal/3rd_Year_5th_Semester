
# TCP
# import socket

# def server_program():
#     host = socket.gethostname()
#     port = 5000
#     address = (host,port)
#     server_socket = socket.socket(socket.AF_INET,socket.SOCK_STREAM)
#     server_socket.bind(address)
#     server_socket.listen(2)
#     print("Tcp server start..........")
#     conn,address = server_socket.accept()

#     data = conn.recv(1024).decode()
#     print(data)
#     data=int(data)
#     b=abs(data)
#     type(b)
#     s=0
#     b=str(b)
#     for i in range(1,len(b)):
#         if(i+1)%2 == 0:
#             s=s+int(b[i])
#     print(s)

#     res=str(s)
#     print("result: ",res)
#     conn.send(res.encode())



# if __name__ == "__main__":
#     server_program()



# UDP
import socket

def server_program():
    host = socket.gethostname()
    port = 5000
    address = (host,port)
    server_socket = socket.socket(socket.AF_INET,socket.SOCK_DGRAM)
    server_socket.bind(address)
    

    data,address = server_socket.recvfrom(1024)
    data = data.decode()
    if data.isdigit():
        port_no=int(data)
        if 0<=port_no<=65535 :
            valid=True
        else:
            valid=False
    else:
        valid=False

    if valid:
        res = f"'{data}' is a valid port no"
    else:
        res = f"'{data}' is no a valid port no"

    # print(data)
    # data=int(data)
    # b=abs(data)
    # type(b)
    # s=0
    # b=str(b)
    # for i in range(1,len(b)):
    #     if(i+1)%2 == 0:
    #         s=s+int(b[i])
    # print(s)

    # res=str(s)
    print("result: ",res)
    server_socket.sendto(res.encode(),address)



if __name__ == "__main__":
    server_program()