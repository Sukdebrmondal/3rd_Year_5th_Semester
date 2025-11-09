import socket   

def client_program():
    # Get the hostname of the machine
    host = socket.gethostname()  
    port = 5000  
    serveraddress = (host, port)

    # Create a UDP socket 
    client_socket = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)
    print("UDP Client running.....")

    while True:
        # Take input from user
        a = input("Enter the Amount: ")
        
        # If user wants to exit
        if a.lower().strip() == "exit":
            client_socket.sendto("exit".encode(), serveraddress)  # notify server
            print("Client shutting down.")
            break

        b = input("Enter the Rate: ")
        c = input("Enter the Time in years: ")

        # Combine all values into string
        message = f"{a},{b},{c}"

        # Send the encoded message to the server 
        client_socket.sendto(message.encode(), serveraddress)

        # Receive reply (calculated interest) from server 
        data, address = client_socket.recvfrom(1024)

        # Print the result received from the server
        print("Received from server:", data.decode())
        print("\n")

    # Close the client socket after communication is done
    client_socket.close()

if __name__ == '__main__':
    client_program()


# PS E:\repositary\3rd_Year_5th_Semester\Computer Networks\practical\ass> python .\1_interest_client.py
# UDP Client running.....
# Enter the Amount: 12500
# Enter the Rate: 12
# Enter the Time in years: 10
# Received from server: 15000.0


# Enter the Amount: 250000
# Enter the Rate: 17
# Enter the Time in years: 25
# Received from server: 1062500.0


# Enter the Amount: exit
# Client shutting down.
# PS E:\repositary\3rd_Year_5th_Semester\Computer Networks\practical\ass> 