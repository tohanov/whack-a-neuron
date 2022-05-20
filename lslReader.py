from asyncio.windows_events import NULL
from pylsl import StreamInlet, resolve_stream
from pyray import *
import time
import random


outputList = []
timestampDuration = 5 # 5 # seconds
readingDuration = timestampDuration * 60 # seconds
outputFile = "trainingOutput.csv"
timeSeriesChannelName = "obci_eeg1"
fftChannelName = "obci_eeg2"


def startSequence(inlet, file):
	init_window(640, 640, "Sample Data Collection")
	set_target_fps(60)

	rightArrow =  load_texture("images/right-arrow.png");
	leftArrow = load_texture("images/left-arrow.png");
	stop = load_texture("images/stop.png");

	namedInstructions = {
		rightArrow : "right",
		leftArrow : "left",
		stop : "idle"
	}

	sequence = readingDuration // timestampDuration * [rightArrow, leftArrow, stop]
	random.shuffle(sequence) # random list of instructions to display

	# file.write(str([namedInstructions[x] for x in sequence]) + "\n")
	
	i = 0
	readingTime1 = inlet.pull_sample()[1]
	# while not window_should_close():
	while not window_should_close() and i < len(sequence):
		begin_drawing()
		clear_background(WHITE)
		draw_texture(sequence[i], 0, 0, WHITE)
		end_drawing()

		readingTime2 = read_signal(namedInstructions[sequence[i]], inlet, file)

		if (readingTime2 - readingTime1 >= timestampDuration):
			i += 1
			readingTime1 = readingTime2

	close_window()



def read_signal(label, inlet, file):
	# while True:
	# get a new sample (you can also omit the timestamp part if you're not
	# interested in it)
	sample, timestamp = inlet.pull_sample()
	# print(timestamp, sample)
	# file.write(f"{label},{timestamp},{','.join([str(x) for x in sample])}\n")
	outputList.append((label, timestamp, sample))
	# },{','.join([str(x) for x in sample])}\n")

	return timestamp



def main():
	# first resolve an EEG stream on the lab network
	print("looking for an EEG stream...")
	streams = resolve_stream('type', 'EEG')

	# print(streams[0].name())
	# create a new inlet to read from the stream
	# inlet = StreamInlet(streams[0])
	inlet = False

	for stream in streams:
		if stream.name() == timeSeriesChannelName:
			inlet = StreamInlet(stream)
			break

	if not inlet:
		print("\nchannel name not found\n")
		exit(0)
	

	startSequence(inlet, file)

	# print(outputList)
	
	file = open(outputFile,"w")

	for record in outputList:
		file.write(
			f"{record[0]},{record[1]},{','.join([str(x) for x in record[2]])}\n"
			)


	# file.write('\n'.join(outputList))



if __name__ == '__main__':
	# main()
	main()
else:
	print("not main")