# udp
# import socket


# def server():
#     host=socket.gethostname()
#     port=6000
#     server_socket = socket.socket(socket.AF_INET,socket.SOCK_DGRAM)
#     address=(host,port)

#     server_socket.bind(address)
#     data,add = server_socket.recvfrom(1024)
#     print(data.decode())
#     server_socket.sendto("sukdeb".encode(),add)


#     server_socket.close()

# if __name__ == '__main__':
#     server()





# import socket


# def server():
#     host=socket.gethostname()
#     port=6000
#     server_socket = socket.socket(socket.AF_INET,socket.SOCK_STREAM)
#     address=(host,port)

#     server_socket.bind(address)
#     server_socket.listen(3)
#     conn,add = server_socket.accept()
#     data = conn.recv(1024)
#     conn.send("sukdeb".encode())

#     print(data.decode())



# if __name__ == '__main__':
#     server()



# import socket

# def server():
#     host = socket.gethostname()
#     port = 6000

#     server_socket = socket.socket(socket.AF_INET,socket.SOCK_DGRAM)
#     address = (host,port)
#     server_socket.bind(address)
#     print("UDP server start now ")
#     while True:

#         data, add = server_socket.recvfrom(1024)
#         message = data.decode().strip()
#         if message.lower()== 'exit':
#             print("server off")
#             break
#         print(message)

#         p,t,r = map(str, message.split(","))
#         p=float(p)
#         t = float(t)
#         r = float(r)

#         result = (p*t*r)/100
#         result=str(result)
#         print("the result print from the server side: ",result)
#         server_socket.sendto(result.encode(),add)
#     server_socket.close()

# if __name__ == '__main__':
#     server()




# import socket

# def server():
#     host = socket.gethostname()
#     port = 6000

#     server_socket = socket.socket(socket.AF_INET,socket.SOCK_DGRAM)
#     address = (host,port)
#     server_socket.bind(address)
#     print("UDP server start now ")
#     while True:

#         data, add = server_socket.recvfrom(1024)
#         message = data.decode().strip()
#         if message.lower()== 'exit':
#             print("server off")
#             break
#         print(message)

        
#         p=int(message)
#         j=str(p)
#         m=0
#         for i in range (1,len(j),2):
#            m = m + int(j[i])
#         print(m)
#         result = str(m)

#         print("the result print from the server side: ",result)
#         server_socket.sendto(result.encode(),add)
#     server_socket.close()

# if __name__ == '__main__':
#     server()



# import socket
# import os
# def server():
#     host = socket.gethostname()
#     port = 6000

#     server_socket = socket.socket(socket.AF_INET,socket.SOCK_DGRAM)
#     address = (host,port)
#     server_socket.bind(address)
#     print("UDP server start now ")
#     while True:

#         data, add = server_socket.recvfrom(1024)

#         file = data.decode().strip()
#         if file.lower()== 'exit':
#             print("server off")
#             break
#         print(file)

#         if os.path.exists(file):
#             f = open(file,'r')
#             content = f.read()
#             print("the file is present here and the content:",content)
#             server_socket.sendto(content.encode(),add)
#         else:
#             mess = "not exits"
#             server_socket.sendto(mess.encode(),add)



        
       

        
#     server_socket.close()

# if __name__ == '__main__':
#     server()



# try:
#     if os.path.exists(file1) and os.path.exists(file2):
#         f=open(file1,'r')
#         content = f.read()
#         f.close()

#         e= open(file2,'w')
#         e.write(content)
#         e.close()
#         c="copty done"
#     else:
#         c="not copy"
# except Exception as e :
#     print(e)
#     c="error"









