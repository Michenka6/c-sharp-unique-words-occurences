import json
import sys

def sort_json_file(input_file, output_file):
    with open(input_file, 'r') as infile:
        data = json.load(infile)

    # Sort the JSON data
    sorted_data = json.dumps(data, sort_keys=True, indent=4)

    with open(output_file, 'w') as outfile:
        outfile.write(sorted_data)

def compare_json_files(file1, file2):
    with open(file1, 'r') as f1, open(file2, 'r') as f2:
        data1 = json.load(f1)
        data2 = json.load(f2)

    # Compare JSON data
    if data1 == data2:
        print(f"The JSON files are identical. {file1} {file2}" )
    else:
        print("The JSON files are different.")



sort_json_file("./occurence-tables/01-solution.json", "./occurence-tables/01-solution-sorted.json")
sort_json_file("./occurence-tables/02-solution.json", "./occurence-tables/02-solution-sorted.json")
sort_json_file("./occurence-tables/03-solution.json", "./occurence-tables/03-solution-sorted.json")
sort_json_file("./occurence-tables/04-solution.json", "./occurence-tables/04-solution-sorted.json")

compare_json_files("./occurence-tables/01-solution-sorted.json","./occurence-tables/02-solution-sorted.json")
compare_json_files("./occurence-tables/01-solution-sorted.json","./occurence-tables/03-solution-sorted.json")
compare_json_files("./occurence-tables/01-solution-sorted.json","./occurence-tables/04-solution-sorted.json")

compare_json_files("./occurence-tables/02-solution-sorted.json","./occurence-tables/01-solution-sorted.json")
compare_json_files("./occurence-tables/02-solution-sorted.json","./occurence-tables/03-solution-sorted.json")
compare_json_files("./occurence-tables/02-solution-sorted.json","./occurence-tables/04-solution-sorted.json")

compare_json_files("./occurence-tables/03-solution-sorted.json","./occurence-tables/01-solution-sorted.json")
compare_json_files("./occurence-tables/03-solution-sorted.json","./occurence-tables/02-solution-sorted.json")
compare_json_files("./occurence-tables/03-solution-sorted.json","./occurence-tables/04-solution-sorted.json")

compare_json_files("./occurence-tables/04-solution-sorted.json","./occurence-tables/01-solution-sorted.json")
compare_json_files("./occurence-tables/04-solution-sorted.json","./occurence-tables/02-solution-sorted.json")
compare_json_files("./occurence-tables/04-solution-sorted.json","./occurence-tables/03-solution-sorted.json")
