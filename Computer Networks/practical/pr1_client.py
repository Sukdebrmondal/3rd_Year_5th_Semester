
# udp
# import socket

# def client():
#     host=socket.gethostname()
#     port=6000
    
#     client_socket = socket.socket(socket.AF_INET,socket.SOCK_DGRAM)
#     address=(host,port)

#     client_socket.sendto("rajkumar".encode(),address)
#     data,add = client_socket.recvfrom(1024)
#     print(data.decode())

#     client_socket.close()

# if __name__ == '__main__':
#     client()




# import socket

# def client():
#     host=socket.gethostname()
#     port=6000

#     client_socket = socket.socket(socket.AF_INET,socket.SOCK_STREAM)
#     address=(host,port)
    

#     client_socket.connect(address)
#     client_socket.send("rajkumar".encode())
#     data = client_socket.recv(1024).decode()
#     print(data)

# if __name__ == '__main__':
#     client()






# import socket

# def client():
#     host = socket.gethostname()
#     port = 6000

#     client_socket = socket.socket(socket.AF_INET,socket.SOCK_DGRAM)
#     address = (host,port)
#     print("UDP client runnig")

#     # input
#     while True:

#         p=input("enter the amount: ")
#         if p.lower().strip()=='exit':
#             client_socket.sendto('exit'.encode(),address)
#             print("client socket shut down")
#             break
#         t = input("enter the time: ")
#         r = input("enter the rate of interest: ")

#         message = f'{p},{t},{r}'

#         client_socket.sendto(message.encode(),address)
#         data, add = client_socket.recvfrom(1024)
#         me = data.decode()
#         print("the calculated resut show from the client side: ",me)
#     client_socket.close()

# if __name__ == '__main__':
#     client()





# import socket

# def client():
#     host = socket.gethostname()
#     port = 6000

#     client_socket = socket.socket(socket.AF_INET,socket.SOCK_DGRAM)
#     address = (host,port)
#     print("UDP client runnig")

#     # input
#     while True:

#         q=input("enter the number: ")
#         if q.lower().strip()=='exit':
#             client_socket.sendto('exit'.encode(),address)
#             print("client socket shut down")
#             break
        

#         message = q

#         client_socket.sendto(message.encode(),address)
#         data, add = client_socket.recvfrom(1024)
#         me = data.decode()
#         print("the calculated resut show from the client side: ",me)
#     client_socket.close()

# if __name__ == '__main__':
#     client()


import socket

def client():
    host = socket.gethostname()
    port = 6000

    client_socket = socket.socket(socket.AF_INET,socket.SOCK_DGRAM)
    address = (host,port)
    print("UDP client runnig")

    # input
    while True:

        q=input("enter the filename: ")
        if q.lower().strip()=='exit':
            client_socket.sendto('exit'.encode(),address)
            print("client socket shut down")
            break
        

        message = q

        client_socket.sendto(message.encode(),address)
        data, add = client_socket.recvfrom(1024)
        me = data.decode()
        print("the calculated resut show from the client side: ",me)
    client_socket.close()

if __name__ == '__main__':
    client()







