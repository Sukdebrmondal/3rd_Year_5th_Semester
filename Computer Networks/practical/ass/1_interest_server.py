import socket   

def server_program():
    host = socket.gethostname()   # local host
    port = 5000                   # Port number 
    print("->" + host)

    # Create a UDP socket 
    server_socket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)

    # Bind the socket with the host and port 
    server_socket.bind((host, port)) 
    print("UDP Server running.....")

    while True:
        # Receive data from client 
        data, address = server_socket.recvfrom(1024)
        # Decode the data into string
        message = data.decode().strip()
        print(message)
        # If message is "exit", shut down the server
        if message.lower() == "exit":
            print("Server shutting down")
            break

        # Split the received string 
        a, b, c = map(str, message.split(","))  

        # Convert extracted string values to float 
        principal = float(a)   # Principal Amount
        rate = float(b)        # Rate of Interest
        time = float(c)        # Time 

        # Calculate Simple Interest 
        result = (principal * rate * time) / 100
        interest = str(result)
        # Print the interest value 
        print("The interest is: ", interest)
        print("\n")
        # Send the calculated interest to the client
        server_socket.sendto(interest.encode(), address)

    server_socket.close()

if __name__ == '__main__':
    server_program()


# PS E:\repositary\3rd_Year_5th_Semester\Computer Networks\practical\ass> python .\1_interest_server.py
# ->SUKDEB
# UDP Server running.....
# 12500,12,10
# The interest is:  15000.0


# 250000,17,25
# The interest is:  1062500.0


# exit
# Server shutting down