"""Example program to show how to read a multi-channel time series from LSL."""

from pylsl import StreamInlet, resolve_stream
from pyray import *

def drawWindows():
	init_window(800, 450, "Sample Data Collection")

	while not window_should_close():
		begin_drawing()
		clear_background(WHITE)
		draw_text("Right Hand", 190, 200, 20, VIOLET)
		end_drawing()

	close_window()


def main():
	# first resolve an EEG stream on the lab network
	print("looking for an EEG stream...")
	streams = resolve_stream('type', 'EEG')

	# print(streams[0].name())
	# create a new inlet to read from the stream
	# inlet = StreamInlet(streams[0])

	for stream in streams:
		if stream.name() == 'obci_whackaneuron':
			inlet = stream
			break

	if not inlet:
		print("\nchannel name not found\n")

	file = File.open("output","w")

	while True:
		# get a new sample (you can also omit the timestamp part if you're not
		# interested in it)
		sample, timestamp = inlet.pull_sample()
		# print(timestamp, sample)
		file.write(timestamp, sample)


if __name__ == '__main__':
	# main()
	drawWindows()
else:
	print("not main")