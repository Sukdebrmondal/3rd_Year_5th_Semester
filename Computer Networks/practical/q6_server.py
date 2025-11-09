# # Develop a client-Server application using TCP where the client will send two file names to 
# # the server and the server will copy the content of the first file into the second file. After 
# # copying is done, the server will send an appropriate message to the client. The second file 
# # should be initially empty. Assume that both files are present at the server. 



import socket
import os

def server_program():
    host = socket.gethostname()   # get local host name
    port = 5000                   # choose port number 

    print("Server is starting on host:", host)

    # create server socket )
    server_socket = socket.socket(socket.AF_INET, socket.SOCK_STREAM)
    server_socket.bind((host, port))   # bind host and port
    server_socket.listen()             # listen for client connections

    conn, address = server_socket.accept()   # accept connection
    print("Connected client: " + str(address))

    while True:
        data = conn.recv(1024).decode()      # receive filenames from client
        if not data:
            print("Server shutting down.")
            break
        file1, file2 = map(str, data.split(","))  # split filenames
        print(file1, file2)

        try:
            if os.path.exists(file1) and os.path.exists(file2):   # check both files
                f = open(file1, "r")     # open source file
                content = f.read()       # read content
                f.close()

                e = open(file2, "w")     # open destination file
                e.write(content)         # write content
                e.close()
                c = "Content copied successfully!!"
            else:
                c = "File not found"
        except Exception as e:
            print(e)
            c = "Error during copy"

        print("Server response: " + c)
        conn.send(c.encode())     # send response to client

    server_socket.close()

if __name__ == "__main__":
    server_program()


# Server is starting on host: SUKDEB
# Connected client: ('192.168.0.104', 65520)
# test1.txt test2.txt
# Server response: Content copied successfully!!
# file.txt file2.txt
# Server response: File not found
# Server shutting down.